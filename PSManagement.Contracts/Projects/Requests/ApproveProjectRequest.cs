﻿using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Projects.Requests
{
    public record ApproveProjectRequest(
    Aggreement ProjectAggreement,
    int ProjectId
    );

}