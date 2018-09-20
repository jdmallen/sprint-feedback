using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JDMallen.Toolbox.Interfaces;
using JDMallen.Toolbox.Models;
using Microsoft.AspNetCore.Mvc;
using SprintFeedback.Data.Context.EFCore.Repositories;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Parameters;

namespace SprintFeedback.Web.Controllers
{
	[Route("api/feedback")]
	[ApiController]
	public class ApiFeedbackController : ControllerBase
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;

		public ApiFeedbackController(
			IUnitOfWorkFactory unitOfWorkFactory)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
		}

		[HttpGet]
		public async Task<ActionResult<IPagedResult<Feedback>>> Find(
			[FromQuery] FeedbackParameters parameters)
		{
			using (var uow = _unitOfWorkFactory.GetUnitOfWork())
			{
				return Ok(await uow.FeedbackRepository.FindPaged(parameters));
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Feedback>> Find(Guid id)
		{
			using (var uow = _unitOfWorkFactory.GetUnitOfWork())
			{
				return Ok(await uow.FeedbackRepository.Get(id));
			}
		}

		// POST api/values
		[HttpPost]
		public async Task<ActionResult<Feedback>> Post(
			[FromBody] Feedback feedback)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			Feedback added;
			using (var uow = _unitOfWorkFactory.GetUnitOfWork())
			{
				uow.Begin();
				added = await uow.FeedbackRepository.Add(feedback);
				uow.Commit();
			}

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

			Feedback updated;
			using (var uow = _unitOfWorkFactory.GetUnitOfWork())
			{
				uow.Begin();
				updated = await uow.FeedbackRepository.Update(feedback);
				uow.Commit();
			}

			return Ok(updated);
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			Feedback deleted;
			using (var uow = _unitOfWorkFactory.GetUnitOfWork())
			{
				uow.Begin();
				deleted = await uow.FeedbackRepository.Remove(id);
				uow.Commit();
			}

			return Ok(deleted);
		}
	}
}
