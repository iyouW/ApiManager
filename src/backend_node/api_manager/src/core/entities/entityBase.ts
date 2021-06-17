import { Column, PrimaryColumn } from 'typeorm'

export class EntityBase {

    @PrimaryColumn({
        name:'id'
    })
    public id: string

    @Column({
        name:'is_deleted'
    })
    public isDeleted: boolean

    @Column({
        name:'created_date'
    })
    public createdDate: Date

    @Column({
        name:'latest_updated_date'
    })
    public latestUpdatedDate: Date

    @Column({
        name:'created_account_id'
    })
    public createdAccountId: string

    @Column({
        name:'latest_updated_account_id'
    })
    public latestUpdatedAccountId: string
}