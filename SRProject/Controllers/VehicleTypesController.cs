﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SRProject.Data;
using SRProject.Models;

namespace SRProject.Controllers
{
    public class VehicleTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleType.ToListAsync());
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleTypeId,VehicleTypeName,Description")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                vehicleType.VehicleTypeId = Guid.NewGuid();
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("VehicleTypeId,VehicleTypeName,Description")] VehicleType vehicleType)
        {
            if (id != vehicleType.VehicleTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeExists(vehicleType.VehicleTypeId))
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
            return View(vehicleType);
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehicleType
                .FirstOrDefaultAsync(m => m.VehicleTypeId == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicleType = await _context.VehicleType.FindAsync(id);
            _context.VehicleType.Remove(vehicleType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeExists(Guid id)
        {
            return _context.VehicleType.Any(e => e.VehicleTypeId == id);
        }
    }
}
