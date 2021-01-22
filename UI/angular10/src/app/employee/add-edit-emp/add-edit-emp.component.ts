import { Component, OnInit,Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() emp:any;
  EmployeeId:string="";
  EmployeeName:string="";
  Department:unknown;
  DateOfJoining:unknown;
  PhotoFileName:string="";
  PhotoFilePath:string="";


  // type: {id:number, name:string}[] = [
  //   {"id":0, "name":"ab"}
  // ];

  DepartmentsList: Array<{ Id: number, Name: string }> = []

  //DepartmentsList:any=[];

  ngOnInit(): void {
    this.loadDepartmentList();
    
  }

  loadDepartmentList(){
    this.service.GetAllDepartmentsName().subscribe((data:any)=>{
      this.DepartmentsList=data;

      this.EmployeeId=this.emp.EmployeeId;
      this.EmployeeName=this.emp.EmployeeName;
      this.Department=this.emp.Department;
      this.DateOfJoining=this.emp.DateOfJoining;
      this.PhotoFileName=this.emp.PhotoFileName;
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    });
    
  }

  addEmployee(){
    var val = { 
                Name:this.EmployeeName,
                Department:this.DepartmentsList.find(i => i.Name === this.Department),
                DepartmentId:this.DepartmentsList.find(i => i.Name === this.Department)?.Id,
                DateOfJoin:this.DateOfJoining,
                PhotoFileName:this.PhotoFileName};
      
    this.service.addEmployee(val).subscribe(res=>{
      alert(res.toString());      
    });
  }

  updateEmployee(id:any){
    
    var val = { Id:id,
                Name:this.EmployeeName,
                Department:this.DepartmentsList.find(i => i.Name === this.Department),
                DepartmentId:this.DepartmentsList.find(i => i.Name === this.Department)?.Id,
                DateOfJoin:this.DateOfJoining,
                PhotoFileName:this.PhotoFileName};
console.log(id);
    this.service.updateEmployee(val).subscribe(res=>{
    alert(res.toString());
    });
  }


  uploadPhoto(event:any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.UploadPhoto(formData).subscribe((data:any)=>{
      this.PhotoFileName=data.toString();
      this.PhotoFilePath=this.service.PhotoUrl+this.PhotoFileName;
    })
  }

}
