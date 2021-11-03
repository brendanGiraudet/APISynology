using APISynology.Dtos;
using Bogus;

namespace APISynology.Tests
{
    public static class FakerUtils
    {
        public static Faker<SynologyResponseWithData<SynologyDataLoginResponse>> ErrorSynologyDataLoginResponseFaker => new Faker<SynologyResponseWithData<SynologyDataLoginResponse>>()
            .RuleFor(r => r.Success, faker => false)
            .RuleFor(r => r.Error, faker => SynologyErrorResponseFaker.Generate());

        public static Faker<SynologyErrorResponse> SynologyErrorResponseFaker => new Faker<SynologyErrorResponse>()
        .RuleFor(r => r.Code, faker => faker.Random.String2(3));

        public static Faker<SynologyResponseWithData<SynologyDataLoginResponse>> SuccessSynologyDataLoginResponseFaker => new Faker<SynologyResponseWithData<SynologyDataLoginResponse>>()
            .RuleFor(r => r.Success, faker => true)
            .RuleFor(r => r.Data, faker => SynologyDataLoginResponseFaker.Generate());

        public static Faker<SynologyDataLoginResponse> SynologyDataLoginResponseFaker => new Faker<SynologyDataLoginResponse>()
        .RuleFor(r => r.Sid, faker => faker.Random.String2(3));

        public static Faker<SynologyResponseWithData<SynologyDataFileListResponse>> ErrorSynologyDataFileListResponseFaker => new Faker<SynologyResponseWithData<SynologyDataFileListResponse>>()
            .RuleFor(r => r.Success, faker => false)
            .RuleFor(r => r.Error, faker => SynologyErrorResponseFaker.Generate());

        public static Faker<SynologyResponseWithData<SynologyDataFileListResponse>> SuccessSynologyDataFileListResponseFaker => new Faker<SynologyResponseWithData<SynologyDataFileListResponse>>()
            .RuleFor(r => r.Success, faker => true)
            .RuleFor(r => r.Data, faker => SynologyDataFileListResponseFaker.Generate());

        public static Faker<SynologyDataFileListResponse> SynologyDataFileListResponseFaker => new Faker<SynologyDataFileListResponse>()
        .RuleFor(r => r.Files, faker => SynologyDataFileResponseFaker.Generate(3).ToArray());

        public static Faker<SynologyDataFileResponse> SynologyDataFileResponseFaker => new Faker<SynologyDataFileResponse>()
        .RuleFor(r => r.IsDir, faker => faker.Random.Bool())
        .RuleFor(r => r.Name, faker => faker.Random.String2(3))
        .RuleFor(r => r.Path, faker => faker.Random.String2(3));

        public static Faker<SynologyResponse> ErrorSynologyResponseFaker => new Faker<SynologyResponse>()
            .RuleFor(r => r.Success, faker => false)
            .RuleFor(r => r.Error, faker => SynologyErrorResponseFaker.Generate());

        public static Faker<SynologyResponse> SuccessSynologyResponseFaker => new Faker<SynologyResponse>()
            .RuleFor(r => r.Success, faker => true);
    }
}
