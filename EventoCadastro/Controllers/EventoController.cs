using Microsoft.AspNetCore.Mvc;
using SeuProjeto.ViewModels;

namespace SeuProjeto.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(EventoViewModel info)
        {
            // Validação personalizada - data não pode ser menor que a data atual
            if (info.Data < DateTime.Now.Date)
            {
                ModelState.AddModelError("Data", "A data não pode ser menor que a data atual");
            }

            // Se o modelo não é válido, retorna a view Create com os erros
            if (!ModelState.IsValid)
            {
                return View("Create", info);
            }

            // Aplicação da regra de negócio
            string mensagem;
            if (info.NumeroParticipantes > 100)
            {
                mensagem = "Evento de grande porte";
            }
            else
            {
                mensagem = "Evento cadastrado com sucesso";
            }

            // Enviando mensagem via ViewData
            ViewData["Mensagem"] = mensagem;

            // Retorna a view Resultado com o modelo tratado
            return View("Resultado", info);
        }
    }
}