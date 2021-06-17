import { Context } from 'koa'
import {  Proxy } from '../core/entities/proxy'
import { ConnectionFactory } from '../dal/connectionFactory'

export class ProxyController{

    public static async getListByProject(ctx: Context) : Promise<void> {
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Proxy)
        const proxies = await repo.find()
        ctx.status = 200
        ctx.body = proxies
    }

    public static async put(ctx: Context) : Promise<void>{
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Proxy)
        const { id, name, description } = ctx.request.body as any
        const proxy = await repo.findOne(id)
        proxy.name = name
        proxy.description = description
        await repo.save(proxy)
        ctx.status = 201
        ctx.body = proxy
    }
}