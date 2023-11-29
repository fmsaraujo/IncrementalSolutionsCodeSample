using JetBrains.Annotations;

namespace Console.ServiceContracts.PostureAssessmentsService;

[PublicAPI]
public record CreatePostureAssessmentRequest
{
    public Guid? VEAAssessmentRequestId { get; init; }

    /// <summary>
    ///     The user location ID.
    /// </summary>
    public Guid UserLocationId { get; init; }
}