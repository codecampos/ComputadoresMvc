using ComputadoresMvc.Data;
using ComputadoresMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputadoresMvc.Controllers;

public class ComputadoresController : Controller
{
    private readonly AppDbContext _context;

    public ComputadoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var computadores = await _context.Computadores
            .AsNoTracking()
            .OrderByDescending(c => c.Id)
            .ToListAsync();

        return View(computadores);
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View(new Computador());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(
        [Bind("Nome,Marca,Processador,MemoriaRamGb,ArmazenamentoGb")] Computador computador)
    {
        // Não grava se houver campos ausentes ou valores inválidos.
        if (!ModelState.IsValid)
            return View(computador);

        _context.Computadores.Add(computador);
        await _context.SaveChangesAsync();

        TempData["Sucesso"] = "Computador cadastrado com sucesso!";
        // Redireciona para evitar repetir o POST ao atualizar a página.
        return RedirectToAction(nameof(Index));
    }
}
