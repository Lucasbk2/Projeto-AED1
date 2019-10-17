using System;

class Usuario{

	//Declaração dos Metódos
	private string nome;
	private int idade;
	private string cpf;
	private Livro[] livros;

	//Construtores
	public Usuario(string n, int i, string c,Livro[] liv){
		this.nome = n;
		this.idade = i;
		this.cpf = c;
		this.livros = liv;
	}
 
	public Usuario(){
		this.nome = "";
		this.idade = 0;
		this.cpf = "";
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


}