using JetBrains.Annotations;

namespace Console.ServiceContracts.PostureAssessmentsService;

[PublicAPI]
public record CreatePostureAssessmentResponse
{
    public Guid PostureAssessmentId { get; init; }
}