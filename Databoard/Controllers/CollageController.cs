using Databoard.Data;
using Databoard.Models;
using Databoard.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Databoard.Controllers
{
    public class CollageController : Controller
    {
        private readonly SchoolDbContext dbContext;
        public CollageController(SchoolDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DataViewModel viewModel)
        {
            var collage = new School
            {
                Name = viewModel.Name,
                Medium = viewModel.Medium,
                Establish = viewModel.Establish,
                Address = viewModel.Address,
                Authorised = viewModel.Authorised,
            };
            await dbContext.Borad.AddAsync(collage);
            await dbContext.SaveChangesAsync();
            return View(viewModel); 
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var collage = await dbContext.Borad.ToListAsync();
            return View(collage);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var collage = await dbContext.Borad.FindAsync(Id);
            return View(collage);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(School viewModel)
        {
            var collage = await dbContext.Borad.FindAsync(viewModel.Id);
            if(collage is not null)
            {
                collage.Name= viewModel.Name;
                collage.Medium= viewModel.Medium;
                collage.Establish= viewModel.Establish;
                collage.Address= viewModel.Address;
                collage.Authorised = viewModel.Authorised;

               
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Collage");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(School viewModel )
        {
            var collage = await dbContext.Borad.AsNoTracking().SingleOrDefaultAsync(x=>x.Id==viewModel.Id);
            if( collage is not null)
            {
                dbContext.Borad.Remove(collage);
                await dbContext.SaveChangesAsync(); 
            }
            return RedirectToAction("List", "Collage");
        }

    }
}
