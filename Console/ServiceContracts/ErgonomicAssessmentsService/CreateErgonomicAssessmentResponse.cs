using JetBrains.Annotations;

namespace Console.ServiceContracts.ErgonomicAssessmentsService;

[PublicAPI]
public record CreateErgonomicAssessmentResponse
{
    public Guid ErgonomicAssessmentId { get; init; }
}
