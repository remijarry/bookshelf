import { Author } from './author.model';

export class Book {
  googleBookId: string;
  title: string;
  authors: Author[];
  publisher: string;
  imageLink: string;
  description: string;
  userId: number;
  bookshelfId: number;
  pageCount: number;
  categories: string[];
}
