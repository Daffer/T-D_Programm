#include "formtariration.h"
#include "ui_formtariration.h"
#include <fstream>
#include <string>
#include <QList>

FormTariration::FormTariration(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::FormTariration)
{
    ui->setupUi(this);
    count_tar = 0;
    FILE *f = fopen("tarirations.txt","r");
    while (!feof(f))
    {
        fscanf(f,"%lf",&tarirations[count_tar].value);
        ui->listWidget->addItem(QString("%1").arg(count_tar));
        count_tar++;
    }
}

FormTariration::~FormTariration()
{
    delete ui;
}

/*void FormTariration::on_pushButton_clicked()
{
    int i,j;

    //ui->label_2->setText(QString("%1").arg(tarirations[count_tar-1].value));
}*/

void FormTariration::on_listWidget_itemActivated(QListWidgetItem *item)
{
    emit send_tar_data(tarirations[item->text().toInt()].value);
    close();

}

void FormTariration::on_listWidget_itemClicked(QListWidgetItem *item)
{
    ui->label->setText(QString("%1 мм").arg(tarirations[item->text().toInt()].value));
    ui->label_4->setText(QString("%1 мм").arg(tarirations[item->text().toInt()].value));
}

void FormTariration::on_pushButton_2_clicked()
{
    //emit send_tar_data(1.0);
    close();
}

void FormTariration::on_pushButton_3_clicked()
{
    emit send_tar_data(tarirations[ui->listWidget->selectedItems().takeFirst()->text().toInt()].value);//selectedItems().takeFirst()->text.toInt()].value);
    close();

}
