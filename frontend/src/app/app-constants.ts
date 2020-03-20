export class AppConstants {

    public static baseServer: string = "http://localhost:9000/api";

    get baseServer(): string {
        return this.baseServer;
    }
}
