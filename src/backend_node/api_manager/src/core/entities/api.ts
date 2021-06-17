import { Entity, Column } from 'typeorm'
import { EntityBase } from './entityBase'

export class Api extends EntityBase{

    @Column({
        name:'name'
    })
    public name: string

    @Column({
        name:'description'
    })
    public description: string

    @Column({
        name:'is_supported'
    })
    public isSupported: boolean

    @Column({
        name:'is_parameter_standard'
    })
    public isParameterStandard: boolean

    @Column({
        name:'project_id'
    })
    public projectId: string

    @Column({
        name:'module_id'
    })
    public moduleId: string

    @Column({
        name:'proxy_id'
    })
    public proxyId: string

    @Column({
        name:'author'
    })
    public author: string

    @Column({
        name:'supported_app'
    })
    public supportedApp: string

    @Column({
        name:'map_name'
    })
    public mapName: string

}