﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Query.GetLeaveRequestList;

public class GetLeaveRequestQueryListHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestQueryListHandler(ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
    {
        // employee logged in check

        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetails();
        var requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);


        // Fill requests with employee information

        return requests;
    }
}
