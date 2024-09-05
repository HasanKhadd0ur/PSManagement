using AutoMapper;
using MediatR;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Application.Projects.UseCases.Commands.AddAttachment;
using PSManagement.Application.Projects.UseCases.Commands.CreateProject;
using PSManagement.Application.Projects.UseCases.Queries.GetProject;
using PSManagement.Contracts.Projects.Requests;
using PSManagement.Contracts.Projects.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using PSManagement.Application.Projects.UseCases.Queries.ListAllProject;
using PSManagement.Application.Projects.UseCases.Commands.AddParticipant;
using PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant;
using PSManagement.Application.Projects.UseCases.Commands.AddProjectStep;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader;
using PSManagement.Application.Projects.UseCases.Commands.ApproveProject;
using PSManagement.Application.Projects.UseCases.Queries.GetParticipants;
using PSManagement.Application.Projects.UseCases.Queries.GetProjectAttachments;
using PSManagement.Application.Projects.UseCases.Queries.GetProjectById;
using PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject;
using PSManagement.Application.Projects.UseCases.Commands.CompletePlaningProject;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Projects.UseCases.Commands.CancelProject;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectManager;
using PSManagement.Presentation.Controllers.ApiBase;
using PSManagement.Application.Projects.UseCases.Queries.GetParticipationChangeHistory;
using PSManagement.Application.Projects.UseCases.Queries.GetCompletionContribution;
using PSManagement.Application.Projects.UseCases.Commands.RemoveAttachment;
using PSManagement.Application.Projects.UseCases.Queries.GetProjectCompletion;
using PSManagement.Domain.Identity.Constants;
using Microsoft.AspNetCore.Authorization;
using PSManagement.Application.Projects.UseCases.Queries.GetFileByUrl;

namespace PSManagement.Presentation.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : APIController
    {
        #region Dependency 
        
        private readonly IMediator _sender;
        private readonly IMapper _mapper;
        private readonly ICurrentUserProvider _currentUserProvider;
       
        #endregion Dependency 

        #region Construtor
        public ProjectsController(
            IMapper mapper,
            IMediator sender,
            ICurrentUserProvider currentUserProvider
            )
        {
            _mapper = mapper;
            _sender = sender;
            _currentUserProvider = currentUserProvider;
        }

        #endregion Construtor

        #region Queries 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListAllProjectsRequest request)
        {
            var query = _mapper.Map<ListAllProjectsQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<ProjectDetailsResponse>>>(await _sender.Send(query));

            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<ProjectResponse>>(result));
        }


        [HttpGet("Completion/{id}")]
        public async Task<IActionResult> GetProjectCompletion(int id)
        {
            var query = new GetProjectCompletionQuery(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<ProjectCompletionResponse>>(result));

        }


        [HttpGet("ParticipationChangeHistory/{id}")]
        public async Task<IActionResult> GetPartiipationChangesHistory(int id )
        {
            var query = new GetParticipationChangeHistoryQuery(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<ParticipationChange>>>(result));
        }


        [HttpGet("ByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetProjectsByFilterRequest request)
        {
            GetProjectsByFilterQuery query = _mapper.Map<GetProjectsByFilterQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<ProjectDetailsResponse>>>(result));
        }



        [HttpGet("ByProjectManager")]
        public async Task<IActionResult> GetByPojectManager([FromQuery] GetProjectsByProjectManagerRequest request)
        {
            GetProjectsByFilterQuery query = _mapper.Map<GetProjectsByFilterQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<ProjectDetailsResponse>>>(result));
        }
        #endregion Queries
      
        #region Project Management 

        [HttpPut("ChangeTeamLeader")]
        public async Task<IActionResult> PuttChangeTeamLeader(ChangeProjectTeamLeaderRequest request)
        {
            var query = _mapper.Map<ChangeProjectTeamLeaderCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        [HttpPut("ChangeProjectManager")]
        public async Task<IActionResult> PutProjectManager(ChangeProjectManagerRequest request)
        {
            var query = _mapper.Map<ChangeProjectManagerCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        #endregion Project Management 

        #region Step Management 


        [HttpPost("AddProjectStep")]
        public async Task<IActionResult> PostAddParticipant(AddProjectStepRequest request)
        {
            var query = _mapper.Map<AddProjectStepCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        

        #endregion Step Management 

        #region Project State Operations

        [HttpPost("ApproveProject")]
        public async Task<IActionResult> PostApproveProjectRequest(ApproveProjectRequest request)
        {
            var query = _mapper.Map<ApproveProjectCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        [HttpPost("CancelProject/{id}")]
        public async Task<IActionResult> PostCancelProjectRequest(int id)
        {
            if (_currentUserProvider.EmployeeId is not null)
            {

                int employeeId = _currentUserProvider.EmployeeId.Value;

                var query = new CancelProjectCommand(id, employeeId);

                var result = await _sender.Send(query);

                return HandleResult(result);


            }
            return BadRequest();
        }

        [HttpPost("RePlanProject")]
        public async Task<IActionResult> PostCompleteProjectRequest(RePlanProjectRequest request)
        {
            var query = _mapper.Map<RePlanProjectCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        [HttpPost("CompleteProject")]
        public async Task<IActionResult> PostCompleteProjectRequest(CompleteProjectRequest request)
        {
            var query = _mapper.Map<CompleteProjectCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }


        #endregion Project State Operations

        #region Participation Management 

        [HttpGet("CompletionContributions/{id}")]
        public async Task<IActionResult> GetCompletionContribution(int id)
        {

            var query = new GetCompletionContributionQuery(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeContributionReponse>>>(result));
        }

        [HttpGet("GetParticipants/{id}")]
        public async Task<IActionResult> GetParticipants(int id)
        {
            GetProjectParticipantsQuery query = new(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeParticipateResponse>>>(result));
        }


        [HttpPost("RemoveParticipant")]
        public async Task<IActionResult> PostRemoveParticipant(RemoveParticipantRequest request)
        {
            var query = _mapper.Map<RemoveParticipantCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        [HttpPost("AddParticipant")]
        public async Task<IActionResult> PostAddParticipant(AddParticipantRequest request)
        {
            var query = _mapper.Map<AddParticipantCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }


        [HttpPost("ChangeParticipation")]
        public async Task<IActionResult> PostChangePArticipation(ChangeEmployeeParticipationRequest request)
        {
            var query = _mapper.Map<ChangeEmployeeParticipationCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        #endregion Participation Management 

        #region Propose 

        [HttpPost]
        [Authorize(Roles = RolesNames.SCIENTIFIC_DEPUTY)]
        public async Task<IActionResult> Post([FromBody] CreateProjectRequest request)
        {
            var command = _mapper.Map<CreateProjectCommand>(request);
            var result = await _sender.Send(command);

            if (result.IsSuccess)
            {

                var query = new GetProjectByIdQuery(result.Value);
                var response = await _sender.Send(query);

                return HandleResult(_mapper.Map<Result<ProjectDetailsResponse>>(response));

            }
            else
            {

                return HandleResult(result);

            }

        }

        #endregion Propose

        #region Attachments Management 

        [HttpPost("AddAttachment")]
        public async Task<IActionResult> PostAddAttachment([FromForm] AddAttachmentRequest request)
        {
            var command = _mapper.Map<AddAttachmentCommand>(request);
            var result = await _sender.Send(command);
            return HandleResult(result);

        }

        [HttpPost("RemoveAttachment")]
        public async Task<IActionResult> PostRemoveAttachment( RemoveAttachmentRequest request)
        {
            var command = _mapper.Map<RemoveAttachmentCommand>(request);
            var result = await _sender.Send(command);
            return HandleResult(result);

        }

        [HttpGet("Attachments")]
        public async Task<IActionResult> GetAttachments([FromQuery] GetProjectAttachmentsRequest request)
        {
            var query = _mapper.Map<GetProjectAttachmentsQuery>(request);
            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<AttachmentReponse>>>(result));

        }
        [HttpGet("Attachment")]
        public async Task<IActionResult> GetAttachments([FromQuery] GetFileByUrlRequest request)
        {
            var query = _mapper.Map<GetFileByUrlQuery>(request);
            var result = await _sender.Send(query);
            if(result.IsSuccess){

                var fileAttachment = result.Value;
                // Return the file with the correct content type and file name
               var memoryStream = new MemoryStream();
                await fileAttachment.File.CopyToAsync(memoryStream);
                memoryStream.Position = 0; // Reset the stream position to the beginning

                // Return the file with the correct content type and file name
                return File(memoryStream, fileAttachment.File.ContentType, fileAttachment.AttachmentName);
   
            }

            return BadRequest();
        }
        #endregion Attachments Management 
    }
}
