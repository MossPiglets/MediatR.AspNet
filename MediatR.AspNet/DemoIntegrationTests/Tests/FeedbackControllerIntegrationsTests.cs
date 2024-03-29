﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DemoIntegrationTests.Factories;
using DemoIntegrationTests.Generators;
using FluentAssertions;
using NUnit.Framework;

namespace DemoIntegrationTests.Tests;

public class FeedbackControllerTests {
    private HttpClient _client;
    private FeedbackGenerator _generator = new();
        
    [OneTimeSetUp]
    public void Setup() {
        var factory = new DemoWebApplicationFactory();
        _client = factory.CreateClient();
    }

    [OneTimeTearDown]
    public void CleanUp() {
        _client.Dispose();
    }
    [Test]
    public async Task PostFeedback_ShouldStatusBeOk() {
        // Arrange
        var sendFeedbackCommand = _generator.CreateSendFeedbackCommand();
        //Act
        var response = await _client.PostAsJsonAsync("Feedback", sendFeedbackCommand);
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
