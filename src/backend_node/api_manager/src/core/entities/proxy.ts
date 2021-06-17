import { Entity, Column } from 'typeorm'
import { EntityBase } from './entityBase'

@Entity({
    name:'proxy'
})
export class Proxy extends EntityBase
{
    @Column({
        name:'name'
    })
    public name: string

    @Column({
        name:'description'
    })
    public description: string

    @Column({
        name:'project_id'
    })
    public projectId: string
}