using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.FileProviders;

interface IFileChunk
{
    IFileInfo ParentDocument { get; }
    Stream Data { get; }
}
// Position in chunk array?
// Previous chunk?
// Separate chunk structures for intermediary chunks?

interface IFileChunker
{
    IAsyncEnumerable<IFileChunk> Chunk(IFileInfo file, IFileProvider provider);
}
// Pdf Chunker
// configurable overlap between chunk data.


//TODO: Good use
//PdfParser parser = PdfParser.Create();
//PdfIndexer indexer = PdfIndexer.Create(parser);
//IFileChunker pdfCompositeChunker = Chunker.Create(x => x.UsePdf(o =>
//{
//  o.Overlap = 0.3m;
//  //Configure PDF specific chunking logic.
//}));
//var chunks = pdfCompositeChunker.Chunk("doc-info.pdf");
//await foreach(var chunk in chunks)
//{
//  using StreamReader reader = new(chunk.Data);
//  //Chunk may start with rolling summary or metadata.
//  var content = await reader.ReadToEndAsync();
//  indexer.Index(content);
//}

//TODO: Ideal use
//var pipeline = VectorizerPipline.Create(
//  indexer: PdfIndexer.Create(pdfParser),
//  chunker: Chunker.Create(x => x.UsePdf(o =>
//  {
//      o.Overlap = 0.3m;
//      //Configure PDF specific chunking logic.
//  }))
//);
//IFileInfo pdf = fileProvider.GetFileInfo("doc-info.pdf");
//await pipeline.Process(pdf);

//TODO: More ideal use
//var pipelineBuilder = MemoryIngestionPipeline.CreateBuilder();
//pipelineBuilder.Services.AddSingleton<PdfParser>();
//pipelineBuilder.Services.AddSingleton<PdfVectorIndexer>();
//pipelineBuilder.Services.AddSingleton<PdfGraphIndexer>();
//pipelineBuilder.Services.AddSingleton<PdfChunker>();
//pipelineBuilder.Services.Configure<PdfChunkingOptions>(o =>
//{
//  o.Overlap = 0.3m;
//  //Configure PDF specific chunking logic.
//});
//IFileInfo pdf = fileProvider.GetFileInfo("doc-info.pdf");
//await pipeline.Process(pdf);
