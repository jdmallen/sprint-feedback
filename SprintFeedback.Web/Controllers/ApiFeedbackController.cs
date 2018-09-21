using System;
using System.Threading.Tasks;
using JDMallen.Toolbox.Interfaces;
using JDMallen.Toolbox.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Parameters;
using SprintFeedback.Data.Repositories;

namespace SprintFeedback.Web.Controllers
{
	[Route("api/feedback")]
	[ApiController]
	public class ApiFeedbackController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		private IFeedbackRepository GetFeedbackRepo()
		{
			return _unitOfWork.GetRepository(nameof(Feedback)) as
				       IFeedbackRepository;
		}

		public ApiFeedbackController(
			IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<ActionResult<IPagedResult<Feedback>>> Find(
			[FromQuery] FeedbackParameters parameters)
		{
			return Ok(await GetFeedbackRepo().FindPaged(parameters));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Feedback>> Find(Guid id)
		{
			return Ok(await GetFeedbackRepo().Get(id));
		}

		// POST api/values
		[HttpPost]
		public async Task<ActionResult<Feedback>> Post(
			[FromBody] Feedback feedback)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			_unitOfWork.ResetUnitOfWork();
			var added = await GetFeedbackRepo().Add(feedback);
			_unitOfWork.Commit();

			return CreatedAtAction(nameof(Find), new {added.Id}, added);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public async Task<ActionResult<Feedback>> Put(
			Guid id,
			[FromBody] Feedback feedback)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			_unitOfWork.ResetUnitOfWork();
			var updated = await GetFeedbackRepo().Update(feedback);
			_unitOfWork.Commit();

			return Ok(updated);
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			_unitOfWork.ResetUnitOfWork();
			var deleted = await GetFeedbackRepo().Remove(id);
			_unitOfWork.Commit();

			return Ok(deleted);
		}
	}
}
