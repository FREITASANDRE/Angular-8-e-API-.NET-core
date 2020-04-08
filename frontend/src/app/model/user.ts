import { Address } from './address';

export class User {
    public id: number;
    public name: string;
    public mail: string;
    public password: string;
    public status: string;
    public address?: Address;
}
