import { Photo } from "./photo"

export interface Member {
    username: string
    surname: string
    age: any
    gender: string
    lookingFor: string
    interests: string
    city: string
    country: string
    photos: Photo[]
    photoUrl: string
    knownAs: string
    created: Date
    lastActive: Date
  }