//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ngcd4.Models;

//namespace ngcd4.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DbusersController : ControllerBase
//    {
//        private readonly CoreDbContext _context;

//        public DbusersController(CoreDbContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        [AllowAnonymous]
//        public IActionResult Login([FromRoute] string returnUrl = "")
//        {
//            var model = new Dbuser { ReturnUrl = returnUrl };
//            return View(model);
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginViewModel model, [FromRoute] string returnUrl = null)
//        {
//            ViewData["ReturnUrl"] = returnUrl;
//            if (ModelState.IsValid)
//            {
//                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
//                if (result.Succeeded)
//                {
//                    //update LatestLogin
//                    var user = await _userManager.FindByEmailAsync(model.Email);
//                    user.LatestLogin = DateTime.Now;
//                    await _userManager.UpdateAsync(user);

//                    _logger.LogInformation(1, "User logged in.");
//                    return RedirectToLocal(returnUrl);
//                }
//                if (result.RequiresTwoFactor)
//                {
//                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
//                }
//                if (result.IsLockedOut)
//                {
//                    _logger.LogWarning(2, "User account locked out.");
//                    return View("Lockout");
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//                    return View(model);
//                }
//            }

//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        // GET: api/Dbusers
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<Dbuser>>> GetDbuser()
//        //{
//        //    return await _context.Dbuser.ToListAsync();
//        //}

//        //// GET: api/Dbusers/5
//        //[HttpGet("{id}")]
//        //public async Task<ActionResult<Dbuser>> GetDbuser(string id)
//        //{
//        //    var dbuser = await _context.Dbuser.FindAsync(id);

//        //    if (dbuser == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    return dbuser;
//        //}

//        //// PUT: api/Dbusers/5
//        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
//        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        //[HttpPut("{id}")]
//        //public async Task<IActionResult> PutDbuser(string id, Dbuser dbuser)
//        //{
//        //    if (id != dbuser.Id)
//        //    {
//        //        return BadRequest();
//        //    }

//        //    _context.Entry(dbuser).State = EntityState.Modified;

//        //    try
//        //    {
//        //        await _context.SaveChangesAsync();
//        //    }
//        //    catch (DbUpdateConcurrencyException)
//        //    {
//        //        if (!DbuserExists(id))
//        //        {
//        //            return NotFound();
//        //        }
//        //        else
//        //        {
//        //            throw;
//        //        }
//        //    }

//        //    return NoContent();
//        //}

//        //// POST: api/Dbusers
//        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
//        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        //[HttpPost]
//        //public async Task<ActionResult<Dbuser>> PostDbuser(Dbuser dbuser)
//        //{
//        //    _context.Dbuser.Add(dbuser);
//        //    try
//        //    {
//        //        await _context.SaveChangesAsync();
//        //    }
//        //    catch (DbUpdateException)
//        //    {
//        //        if (DbuserExists(dbuser.Id))
//        //        {
//        //            return Conflict();
//        //        }
//        //        else
//        //        {
//        //            throw;
//        //        }
//        //    }

//        //    return CreatedAtAction("GetDbuser", new { id = dbuser.Id }, dbuser);
//        //}

//        //// DELETE: api/Dbusers/5
//        //[HttpDelete("{id}")]
//        //public async Task<ActionResult<Dbuser>> DeleteDbuser(string id)
//        //{
//        //    var dbuser = await _context.Dbuser.FindAsync(id);
//        //    if (dbuser == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    _context.Dbuser.Remove(dbuser);
//        //    await _context.SaveChangesAsync();

//        //    return dbuser;
//        //}

//        //private bool DbuserExists(string id)
//        //{
//        //    return _context.Dbuser.Any(e => e.Id == id);
//        //}
//    }
//}
