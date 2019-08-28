using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.EntityFrameworkCore;
using PinkMilkMedia.Models;

namespace PinkMilkMedia.Controllers
{
    public class UserViewModelsController : Controller
    {
        private readonly PinkMilkMediaContext _context;
        private readonly UserManager<Owner> _userManager;

        public UserViewModelsController(PinkMilkMediaContext context, UserManager<Owner> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserViewModels
        public async Task<IActionResult> Index()
        {
            _context.Owner.ToList();
            var users = ConvertFromDatabase(_context.Owner.ToArray());
            return View(users);
        }

        private IEnumerable<UserViewModel> ConvertFromDatabase(IEnumerable<Owner> owner)
        {
            return owner.Select(u => new UserViewModel()
            {
                EmailAddress = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Id = u.Id,
                Type = (UserType)u.TypeId
            }).ToList();
        }

        // GET: UserViewModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // GET: UserViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            try
            {
                // TODO: Add insert logic here
                var newUser = new Owner()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.EmailAddress,
                    UserName = user.EmailAddress,
                    TypeId = (int)user.Type
                };

                var result = await _userManager.CreateAsync(newUser);
                if (!result.Succeeded)
                {
                    throw new Exception();
                }

                var newRole = string.Empty;
                switch (user.Type)
                {
                    case UserType.Administrator:
                        newRole = Constants.Roles.Admin;
                        break;
                    case UserType.User:
                        newRole = Constants.Roles.User;
                        break;
                    default:
                        break;
                }
                await _userManager.AddToRoleAsync(newUser, newRole);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserViewModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel.FindAsync(id);
            if (userViewModel == null)
            {
                return NotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,EmailAddress,Type")] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserViewModelExists(userViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // GET: UserViewModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userViewModel = await _context.UserViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userViewModel == null)
            {
                return NotFound();
            }

            return View(userViewModel);
        }

        // POST: UserViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userViewModel = await _context.UserViewModel.FindAsync(id);
            _context.UserViewModel.Remove(userViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserViewModelExists(string id)
        {
            return _context.UserViewModel.Any(e => e.Id == id);
        }
    }
}
