import { extension } from 'mime'
import { Entity, Column } from 'typeorm'
import { EntityBase } from './entityBase'

@Entity({
    name:'project'
})
export class Project extends EntityBase{

    @Column({
        name:'name'
    })
    public name: string

    @Column({
        name:'description'
    })
    public description: string    

}