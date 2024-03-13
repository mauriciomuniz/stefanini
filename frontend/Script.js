
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("formCriarTarefa").addEventListener("submit", function(event) {
      event.preventDefault(); // Evita o comportamento padrão do formulário de recarregar a página
  
      // Cria um objeto com os dados do formulário
      var formData = {
        title: document.getElementById("titulo").value,
        description: document.getElementById("descricao").value,
        status: parseInt(document.getElementById("status").value)
      };
  
      fetch('https://localhost:7070/api/Tarefas/Cadastrar', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData) // Converte o objeto em uma string JSON
      })
      .then(response => {
        if (!response.ok) {
          throw new Error('Erro ao criar a tarefa. Código de status: ' + response.status);
        }
        return response.json();
      })
      .then(data => {
        alert('Tarefa criada com sucesso! ID: ' + data.id);
        document.getElementById("formCriarTarefa").reset(); // Limpa o formulário
      })
      .catch(error => {
        alert('Erro ao processar a solicitação: ' + error.message);
      });
    });
  });
  
  

 // pegar o id na pagina e fazer requisição para se comunicar com backend após 
  // apertar botão dispara o evento de click
  document.addEventListener("DOMContentLoaded", function() {
    
    document.getElementById("btnBuscarTodas").addEventListener("click", function() {
        
        fetch('https://localhost:7070/api/Tarefas/Listar')
        .then(response => {
            
            if (!response.ok) {
                throw new Error('Erro ao buscar as tarefas.');
            }
            return response.json();
        })
        .then(data => {
            
            exibirTarefas(data);
        })
        .catch(error => {
            
            alert(error.message);
        });
    });
    });


  // pegar o id na pagina e fazer requisição para se comunicar com backend após digitar o id 
  // e apertar botão dispara o evento de click
  document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("btnBuscarPorId").addEventListener("click", function() {
        var idTarefa = document.getElementById("idTarefa").value;
        if (!idTarefa) {
            alert("Por favor, insira o ID da tarefa.");
            return;
        }
        
        fetch('https://localhost:7070/api/Tarefas/Buscar/' + idTarefa)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao buscar a tarefa.');
            }
            return response.json();
        })
        .then(data => {
            exibirTarefa(data);
        })
        .catch(error => {
            alert(error.message);
        });
    });
    });

  
  
   // função para exibir todas tarefas
   function exibirTarefas(tarefas) {
    var resultado = document.getElementById("resultado");
    resultado.innerHTML = "";
    
    tarefas.forEach(tarefa => {
      resultado.innerHTML += `<p>ID: ${tarefa.id} - Título: ${tarefa.title} - Descrição: ${tarefa.description} - Status: ${tarefa.status}</p>`;
    });
  }
  // função para exibir tarefas por id especifica
  function exibirTarefa(tarefa) {
    var resultado = document.getElementById("resultado");
    resultado.innerHTML = "";
    
    if (tarefa) {
      resultado.innerHTML = `<p>ID: ${tarefa.id} - Título: ${tarefa.title} - Descrição: ${tarefa.description} - Status: ${tarefa.status}</p>`;
    } else {
      resultado.innerHTML = "Tarefa não encontrada.";
    }
  }