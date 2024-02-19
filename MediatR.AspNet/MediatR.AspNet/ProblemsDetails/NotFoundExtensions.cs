using MediatR.AspNet.Exceptions;

namespace MediatR.AspNet.ProblemsDetails {
    public class NotFoundExtensions {
        public static NotFoundProblemDetails ToProblemDetails(this NotFoundException ex) {
            var error = new NotFoundProblemDetails {
                Type = "test",
                Status = 404
            };
            return error;
        }
    }
}
// stwórz klasę ApplicationErrrorDetails która będzie domyślna dla wszystkich moich wyjątków
// powinna zawierać: status, code błedu, message
// klasa BaseApplicationException, będzie miała metodę ToProblemDeatils, ma dziedziczyć z exception, ma mieć konstruktor
// który przyjmie wszystko co potrzebne dla problem deatils
// w moim middleware będe miała try i catch BaseApplicationExceptionw
