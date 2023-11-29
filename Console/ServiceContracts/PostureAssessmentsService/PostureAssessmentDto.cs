using JetBrains.Annotations;

namespace Console.ServiceContracts.PostureAssessmentsService;

[PublicAPI]
public record PostureAssessmentDto
{
    public Guid PostureAssessmentId { get; init; }
    public Guid UserAccountId { get; init; }
    public string Description { get; init; } = string.Empty;
}