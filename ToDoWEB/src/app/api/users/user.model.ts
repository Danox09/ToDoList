export class User{
    id!:string;
    firstName!:string;
    lastName!:string;
    email!:string;

    constructor(data: any = null) {
        data = data ? JSON.parse(JSON.stringify(data)) : {};

        this.id = data.id ? data.id : null;
        this.firstName = data.firstName ? data.firstName : null;
        this.lastName = data.lastName ? data.lastName : null;
        this.email = data.email ? data.email : null;
    }
}