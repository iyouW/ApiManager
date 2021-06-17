import { Context } from 'koa'
import { Module } from '../core/entities/module'
import { ConnectionFactory } from '../dal/connectionFactory'

export class ModuleController{

    public static async getListByProject(ctx: Context) : Promise<void> {
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Module)
        const modules = await repo.find()
        ctx.status = 200
        ctx.body = modules
    }

    public static async put(ctx: Context) : Promise<void>{
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Module)
        const { id, name, description } = ctx.request.body as any
        const module = await repo.findOne(id)
        module.name = name
        module.description = description
        await repo.save(module)
        ctx.status = 201
        ctx.body = module
    }
}