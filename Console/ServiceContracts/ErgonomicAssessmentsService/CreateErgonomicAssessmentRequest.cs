using JetBrains.Annotations;

namespace Console.ServiceContracts.ErgonomicAssessmentsService;

[PublicAPI]
public record CreateErgonomicAssessmentRequest
{
    public Guid? VEAAssessmentRequestId { get; init; }

    /// <summary>
    ///     The user location ID.
    /// </summary>
    public Guid UserLocationId { get; init; }

    /// <summary>
    ///     The Ergonomics Questionnaire ID.
    /// </summary>
    public Guid QuestionnaireId { get; init; }
}
