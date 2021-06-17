"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConnectionFactory = void 0;
const typeorm_1 = require("typeorm");
const project_1 = require("../core/entities/project");
class ConnectionFactory {
    static async CreateAsync() {
        if (!this._CONN_) {
            this._CONN_ = await typeorm_1.createConnection({
                type: "mysql",
                host: "localhost",
                port: 3306,
                username: "root",
                password: "123456",
                database: "api_manager",
                entities: [
                    project_1.Project
                ],
                synchronize: false,
                logging: true
            });
        }
        return this._CONN_;
    }
}
exports.ConnectionFactory = ConnectionFactory;
ConnectionFactory._CONN_ = null;
//# sourceMappingURL=connectionFactory.js.map