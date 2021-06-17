import { Context } from 'koa'
import {  Parameter } from '../core/entities/parameter'
import { ConnectionFactory } from '../dal/connectionFactory'

export class ParameterController{

    public static async getListByApi(ctx: Context) : Promise<void> {
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Parameter)
        const parameters = await repo.find()
        ctx.status = 200
        ctx.body = parameters
    }

    public static async put(ctx: Context) : Promise<void>{
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Parameter)
        const { id, name, description } = ctx.request.body as any
        const parameter = await repo.findOne(id)
        parameter.name = name
        parameter.description = description
        await repo.save(parameter)
        ctx.status = 201
        ctx.body = parameter
    }
}