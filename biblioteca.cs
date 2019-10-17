using System;
class Biblioteca{
	
//Declaração dos Atributos
	private string nome;
	private string cep;
	private Usuario[] usuarios;
	private Livro[] livros;
	
//Construtores
	public Biblioteca(string n, string c, Usuario[] user, Livro [] liv){
		this.nome = n;
		this.cep = c;
		this.usuarios = user;
		this.livros = liv;
	}
	public Biblioteca(){
		this.nome = "";
		this.cep = "";
	}
//Métodos get/set
	public string getNome(){
		return nome;
	}
	public void setNome(string n){
		nome = n;
	}


	public string getCep(){
		return cep;
	}
	public void setCep(string c){
		cep = c;
	}

	
	
}