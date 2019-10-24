using System;
using System.IO;
using System.Text;


class Usuario{

	//Declaração dos Metódos
	private string nome;
	private int idade;
	private string senha;
	private bool logado;
	private string cpf;
	private Livro[] livrosUsuario = new Livro [3];

	//Construtores
	public Usuario(string n, int i, string c){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.logado = false;
	}
 
	public Usuario(){
		this.nome = "";
		this.idade = 0;
		this.cpf = "";
		this.logado = false;
	}

	//Métodos get/set
	public string getNome(){
		return nome;
	}
	public void setNome(string n){
		nome = n;
	}

	public int getIdade(){
		return idade;
	}
	public void setIdade(int i){
		idade = i;
	}

	public string getCpf(){
		return cpf;
	}
	public void setCpf(string c){
		cpf = c;
	}
	
	public bool getLogado(){
		return logado;
	}
	public void setLogado(bool b){
		this.logado = b;
	}
	//Métodos Funcionais
	//bi.getLivros()[x].getNome()
	public string AlugarLivro(string livroSelecionado, Biblioteca bi){
		for(int x=0;x<bi.getLivros().Length;x++){
			if(livroSelecionado == bi.getLivros()[x].getNome()){
				for(int y=0;y<livrosUsuario.Length;y++){
					if(livrosUsuario[y] == null){
						livrosUsuario[y] = bi.getLivros()[x];
						bi.getLivros()[x] = null;
						return "Livro adicionado";
					}

				}
			}
				
		}
		return "Livro não adicionado";
	}

	public void MostrarLivrosUsuario(){
		for(int x=0;x<livrosUsuario.Length;x++){
			if(livrosUsuario[x] != null){
				Console.WriteLine(livrosUsuario[x].getNome());
			}
		}
	}
	public string DevolverLivro(string nomeLivro,Biblioteca bi){
		for(int x=0;x<livrosUsuario.Length;x++){
			if(nomeLivro == livrosUsuario[x].getNome()){
				Console.WriteLine("Livro encontrado");
				for(int y=0;y<bi.getLivros().Length;y++){
					if(bi.getLivros()[x] == null){
						bi.getLivros()[y] =livrosUsuario[x];
						livrosUsuario[x]=null;
						return "Livro adicionado";
					}
				} 

			}
		}
		return "Livro não encontrado";

	}
}