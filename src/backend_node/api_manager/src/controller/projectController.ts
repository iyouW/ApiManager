import { Context } from 'koa'
import { Project } from '../core/entities/project'
import { ConnectionFactory } from '../dal/connectionFactory'

export class ProjectController{

    public static async getList(ctx: Context) : Promise<void> {
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Project)
        const projects = await repo.find()
        ctx.status = 200
        ctx.body = projects
    }

    public static async put(ctx: Context) : Promise<void>{
        const conn = await ConnectionFactory.CreateAsync()
        const repo = conn.getRepository(Project)
        const { id, name, description } = ctx.request.body as any
        const project = await repo.findOne(id)
        project.name = name
        project.description = description
        await repo.save(project)
        ctx.status = 201
        ctx.body = project
    }
}