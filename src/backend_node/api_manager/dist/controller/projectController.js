"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ProjectController = void 0;
const project_1 = require("../core/entities/project");
const connectionFactory_1 = require("../dal/connectionFactory");
class ProjectController {
    static async getList(ctx) {
        const conn = await connectionFactory_1.ConnectionFactory.CreateAsync();
        const repo = conn.getRepository(project_1.Project);
        const projects = await repo.find();
        ctx.status = 200;
        ctx.body = projects;
    }
    static async put(ctx) {
        const conn = await connectionFactory_1.ConnectionFactory.CreateAsync();
        const repo = conn.getRepository(project_1.Project);
        const { id, name, description } = ctx.request.body;
        const project = await repo.findOne(id);
        project.name = name;
        project.description = description;
        await repo.save(project);
        ctx.status = 201;
        ctx.body = project;
    }
}
exports.ProjectController = ProjectController;
//# sourceMappingURL=projectController.js.map