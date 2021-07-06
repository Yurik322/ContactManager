using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ContactManager.BLL.DTO;
using ContactManager.BLL.Interfaces;

namespace ContactManager.WebUI.Controllers
{
    /// <summary>
    /// Contacts controller.
    /// </summary>
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILoggerManager _logger;

        public ContactsController(IContactService contactService, ILoggerManager logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        // GET: /contacts
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contactsDto = await _contactService.GetAllContactsAsync();
                return Ok(contactsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetContacts)} action {ex}");
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        // GET: /contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            try
            {
                var contactResult = await _contactService.GetContactById(id);
                return Ok(contactResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetContactsById action: {ex.Message}");
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        // POST: /contacts/upload
        [HttpPost("[action]"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "CSV");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length <= 0) return BadRequest();
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                await using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                _contactService.AddCsvFile(dbPath);
                return Ok(new { dbPath });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UploadContacts action: {ex.Message}");
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        // PUT: /contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(ContactDto contact)
        {
            try
            {
                if (contact == null)
                {
                    _logger.LogError("Contacts object sent from client is null.");
                    return BadRequest("Contacts object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid contact object sent from client.");
                    return BadRequest("Invalid model object");
                }

                await _contactService.EditContactAsync(contact);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateContacts action: {ex.Message}");
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        // DELETE: /contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteContactAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteContact action: {ex.Message}");
                return StatusCode(500, "Internal server error" + ex);
            }
        }
    }
}
