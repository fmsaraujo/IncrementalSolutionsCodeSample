using JetBrains.Annotations;
using PlatformServices;

namespace Console.ServiceContracts.PostureAssessmentsService;

[PublicAPI]
[PlatformService("posture-assessments", "1.0")]
public interface IPostureAssessmentsService
{
    [PlatformServiceOperation("create-posture-assessment")]
    ServiceResult<CreatePostureAssessmentResponse> CreatePostureAssessment(
        CreatePostureAssessmentRequest request);

    [PlatformServiceOperation("get-posture-assessment-results")]
    ServiceResult<PostureAssessmentDto> GetPostureAssessmentResults(GetPostureAssessmentResultsRequest request);
}
