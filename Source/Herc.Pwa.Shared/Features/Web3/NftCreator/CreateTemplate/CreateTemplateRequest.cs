namespace Herc.Pwa.Shared.Features.Web3.NftCreator.CreateTemplate
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class CreateTemplateRequest : BaseRequest, IRequest<CreateTemplateResponse>
  {
    public const string Route = "api/CreateTemplate";

    public string NewTemplateName { get; set; }
    public string NewTemplateSymbol { get; set; }
    public uint  NewTemplateMintLimit { get; set; }
    public uint NewTemplateAttachedTokens { get; set; }
  }

}
