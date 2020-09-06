
export class Task {
    constructor(
        public id?: number,
        public text?: string,
        public category?: string,
        public date?: Date,
        public done?: Boolean) { }
}