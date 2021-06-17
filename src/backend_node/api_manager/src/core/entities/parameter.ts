import { Entity, Column } from 'typeorm'
import { EntityBase } from './entityBase'

export class Parameter extends EntityBase{

    @Column({
        name:'name'
    })
    public name: string

    @Column({
        name:'description'
    })
    public description: string

    @Column({
        name:'comment'
    })
    public comment: string

    @Column({
        name:'type'
    })
    public type: number

    @Column({
        name:'category'
    })
    public category: number

    @Column({
        name:'api_id'
    })
    public apiId: string

    @Column({
        name:'parent_id'
    })
    public parentId: string
}