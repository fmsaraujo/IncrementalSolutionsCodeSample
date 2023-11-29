using JetBrains.Annotations;

namespace Console.ServiceContracts.ErgonomicAssessmentsService;

[PublicAPI]
public record GetErgonomicAssessmentSummaryRequest
{
    public Guid ErgonomicAssessmentId { get; init; }
}
