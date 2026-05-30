using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryProof.API.Controllers;

[ApiController]
[Route("api/v1/pull-completions")]
[Authorize]
public sealed class PullCompletionsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CompletePullResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Complete(
        [FromBody] CompletePullRequest body,
        CancellationToken cancellationToken)
    {
        var command = new CompletePullCommand(
            body.ProductionRunId,
            body.Lines.Select(line => new CompletePullLineInput(
                line.RecipeIngredientId,
                line.ActualQuantity,
                line.ActualUnit,
                line.MemberSplits?
                    .Select(split => new CompletePullMemberSplitInput(
                        split.MemberItemId,
                        split.Quantity,
                        split.Unit))
                    .ToList()))
                .ToList(),
            body.Notes);

        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}

public sealed record CompletePullRequest(
    string ProductionRunId,
    List<CompletePullLineRequest> Lines,
    string? Notes);

public sealed record CompletePullLineRequest(
    string RecipeIngredientId,
    decimal ActualQuantity,
    string ActualUnit,
    List<CompletePullMemberSplitRequest>? MemberSplits);

public sealed record CompletePullMemberSplitRequest(
    string MemberItemId,
    decimal Quantity,
    string Unit);

public sealed record CompletePullCommand(
    string ProductionRunId,
    IReadOnlyList<CompletePullLineInput> Lines,
    string? Notes) : IRequest<CompletePullResult>;

public sealed record CompletePullLineInput(
    string RecipeIngredientId,
    decimal ActualQuantity,
    string ActualUnit,
    IReadOnlyList<CompletePullMemberSplitInput>? MemberSplits);

public sealed record CompletePullMemberSplitInput(string MemberItemId, decimal Quantity, string Unit);

public sealed record CompletePullResult(string PullCompletionId, int LineCount, int SnapshotCount);
