import { UserResponseType } from "./response.model";

export interface User{
    email: string;
    roles: string[];
    name: string;
    token:string;
}

export interface EventResponseVm{
    id:string, 
    name:string, 
    description:string, 
    location:string, 
    dateTime:string, 
    createdAt:string, 
    organizerId:string,
    organizer:UserResponseType,
    imageUrl:string,
    isRegistered:boolean, 
    toggleGuestList :boolean,
    attendees: UserResponseType[] | null,
}