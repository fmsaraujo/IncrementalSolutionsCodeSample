using JetBrains.Annotations;
using PlatformServices;

namespace Console.ServiceContracts.ErgonomicAssessmentsService;

[PublicAPI]
[PlatformService("ergonomic-assessments", "1.0")]
public interface IErgonomicAssessmentsService
{
    [PlatformServiceOperation("create-ergonomic-assessment")]
    ServiceResult<CreateErgonomicAssessmentResponse> CreateErgonomicAssessment(
        CreateErgonomicAssessmentRequest request);

    [PlatformServiceOperation("get-ergonomic-assessment-summary")]
    ServiceResult<ErgonomicAssessmentSummaryDto> GetErgonomicAssessmentSummary(
        GetErgonomicAssessmentSummaryRequest request);
}
