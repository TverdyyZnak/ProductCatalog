export interface JwtModel {
    id: string;
    role: string;
    isBlocked: boolean;
    exp: number
}