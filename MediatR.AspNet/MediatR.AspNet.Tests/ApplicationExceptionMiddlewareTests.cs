using System;
using System.IO.Pipelines;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace MediatR.AspNet.Tests;

public class ApplicationExceptionMiddlewareTests {
    [Test]
    public async Task NotFoundException_ShouldReturnNotFound() {
        // Arrange 
        string json = "";
        RequestDelegate request = _ => throw new NotFoundException();
        var defaultHttpContext = new DefaultHttpContext();
        var response = Substitute.For<HttpResponse>();
        response.BodyWriter.Returns(defaultHttpContext.Response.BodyWriter);
        response.WriteAsync("").Returns(Task.CompletedTask)
            .AndDoes(x => json = x.Arg<string>());
        var context = Substitute.For<HttpContext>();
        context.Response.Returns(response);
        var sut = new ApplicationExceptionMiddleware();
        // Act
        await sut.InvokeAsync(context, request);
        // Assert
        await context.Response.Received(1).WriteAsync("");
        json.Should().NotBeNullOrEmpty();
        var errorDetails = JsonSerializer.Deserialize<ApplicationErrorDetails>(json);
        errorDetails.Code.Should().Be("NotFound");
        errorDetails.Status.Should().Be(StatusCodes.Status404NotFound);
        context.Response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}
