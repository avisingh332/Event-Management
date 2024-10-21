export interface LoginResponse{
    userId:string, 
    name:string, 
    email:string, 
    jwtToken:string, 
    expiresIn:Date, 
    roles:string[],
}

export interface OrganizerEventResponseType{
    id:string, 
    name:string, 
    description:string, 
    location:string, 
    dateTime:string, 
    createdAt:string, 
    organizerId:string,
    organizer:UserResponseType,
    attendees: UserResponseType[],
    imageUrl:string,
}

export interface AttendeeEventResponseType{
    id:string, 
    name:string, 
    description:string, 
    location:string, 
    dateTime:string, 
    createdAt:string, 
    organizerId:string,
    organizer:UserResponseType,
    isRegistered:boolean,
    imageUrl:string,
}

export interface UserResponseType{
    id:string, 
    name:string,
    email:string,
}