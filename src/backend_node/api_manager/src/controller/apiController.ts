import { Context } from 'koa'
import { Api } from '../core/entities/api'
import { ConnectionFactory } from '../dal/connectionFactory'

export class ApiController{

    public static async getListByModule(ctx: Context) : Promise<void> {
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Api)
        const apis = await repo.find()
        ctx.status = 200
        ctx.body = apis
    }

    public static async put(ctx: Context) : Promise<void>{
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Api)
        const { id, name, description } = ctx.request.body as any
        const api = await repo.findOne(id)
        api.name = name
        api.description = description
        await repo.save(api)
        ctx.status = 201
        ctx.body = api
    }
}