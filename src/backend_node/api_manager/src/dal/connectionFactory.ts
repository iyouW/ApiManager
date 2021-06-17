import { Connection, createConnection } from 'typeorm'
import { Project } from '../core/entities/project'

export class ConnectionFactory{
    
    static _CONN_: Connection = null

    static async CreateAsync(){
        if( !this._CONN_ ){
            this._CONN_ = await createConnection({
                type: "mysql",
                host: "localhost",
                port: 3306,
                username: "root",
                password: "123456",
                database: "api_manager",
                entities: [
                   Project
                ],
                synchronize: false,
                logging:true
            })
        }
        return this._CONN_
    }
}