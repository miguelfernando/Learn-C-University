import { Component, OnInit } from '@angular/core';
import { Aluno } from '../aluno';
import { Observable } from 'rxjs';
import { AlunoService } from '../aluno.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit {
  dataSaved = false;  
  alunoForm: any;  
  allAlunos: Observable<Aluno[]>;  
  alunoIdUpdate = null;  
  massage = null;    
  constructor(private formbulider: FormBuilder, private alunoService:AlunoService) { }   
  ngOnInit() {  
    this.alunoForm = this.formbulider.group({  
      Nome: ['', [Validators.required]],  
      Email: ['', [Validators.required]],  
      Endereco: ['', [Validators.required]],  
      Telefone: ['', [Validators.required]],  
      Cidade: ['', [Validators.required]],  
    });  
    this.loadAllAlunos();  
   }
   loadAllAlunos() {  
      this.allAlunos = this.alunoService.getAllAluno();  
   }     
   onFormSubmit() {  
      this.dataSaved = false;  
      const aluno = this.alunoForm.value;  
      this.CreateAluno(aluno);  
      this.alunoForm.reset();  
   }    
   loadAlunoToEdit(alunoId: string) {  
      this.alunoService.getAlunoById(alunoId).subscribe(aluno=> {  
        this.massage = null;  
        this.dataSaved = false;  
        this.alunoIdUpdate = aluno.Id;  
        this.alunoForm.controls['Nome'].setValue(aluno.Nome);  
        this.alunoForm.controls['Email'].setValue(aluno.Email);  
        this.alunoForm.controls['senha'].setValue(aluno.Senha);  
        this.alunoForm.controls['Status'].setValue(aluno.Status);  
        this.alunoForm.controls['Sexo'].setValue(aluno.Sexo);  
      });  
    }  
    CreateAluno(aluno: Aluno) {  
      if (this.alunoIdUpdate == null) {  
        this.alunoService.createAluno(aluno).subscribe(  
          () => {  
            this.dataSaved = true;  
            this.massage = 'Registro salvo com sucesso';  
            this.loadAllAlunos();  
            this.alunoIdUpdate = null;  
            this.alunoForm.reset();  
          }  
        );  
      } else {  
        aluno.Id = this.alunoIdUpdate;  
        this.alunoService.updateAluno(this.alunoIdUpdate, aluno).subscribe(() => {  
          this.dataSaved = true;  
          this.massage = 'Registro Atualizado com sucesso';  
          this.loadAllAlunos();  
          this.alunoIdUpdate = null;  
          this.alunoForm.reset();  
        });  
      }  
    }   
    deleteAluno(alunoId: string) {  
      if (confirm("Deseja deletar este aluno ?")) {   
      this.alunoService.deleteAlunoById(alunoId).subscribe(() => {  
        this.dataSaved = true;  
        this.massage = 'Registro deletado com sucesso';  
        this.loadAllAlunos();  
        this.alunoIdUpdate = null;  
        this.alunoForm.reset();  
      });  
    }  
  }  

  resetForm() {  
      this.alunoForm.reset();  
      this.massage = null;  
      this.dataSaved = false;  
    }

}
