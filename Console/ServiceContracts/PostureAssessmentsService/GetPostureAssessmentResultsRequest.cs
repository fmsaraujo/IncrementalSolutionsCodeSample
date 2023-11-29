using JetBrains.Annotations;

namespace Console.ServiceContracts.PostureAssessmentsService;

[PublicAPI]
public record GetPostureAssessmentResultsRequest
{
    public Guid PostureAssessmentId { get; init; }
}