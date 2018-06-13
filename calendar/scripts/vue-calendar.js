Vue.component("mCalendar",{
	props:["child"],
	data:function(){
		return {
			open:false,
			value:this.child.now,
			datatop:"",
			datalist:[],
			year:"",
			month:""
		}
	},
	methods:{
		showCalendar:function(){
			this.open=!this.open;
			if(this.open){
				if(this.value){
					this.value=this.child.now.replace(/-/g,"/");
				}else{
					this.value=new Date().getFullYear()+'/'+(Number(new Date().getMonth())+1)+'/'+new Date().getDate();
				};
				if(this.isDate()){
					this.setDateInfo();
				};
			};
		},
		setDateInfo:function(dates){ 
			dates=dates||this.value;
			var Dates=new Date(dates);
			this.year=Dates.getFullYear();
			this.month=Dates.getMonth()+1;
			var day=Dates.setDate(1);
			var week=new Date(day).getDay();
			var num=new Number;
			if(this.month==2){
				num=this.year%100==0?(this.year%400==0?29:28):(this.year%4==0?29:28);
			}else if(this.month==1||this.month==3||this.month==5||this.month==7||this.month==8||this.month==10||this.month==12){
				num=31;
			}else{
				num=30;
			};
			this.datalist=[];
			for(var i=1;i<=(num+week);i++){
				if(i>week){
					var one=new Array;
					one.push(this.year);
					one.push(this.zeroFill(this.month));
					one.push(this.zeroFill(i-week));
					var start=this.child.start?this.child.start.split("-"):0;
					start=this.zeroFill(start[0])+'/'+this.zeroFill(start[1])+'/'+this.zeroFill(start[2]);
					start=new Date(start);
					var end=this.child.end?this.child.end.split("-"):0;
					end=this.zeroFill(end[0])+'/'+this.zeroFill(end[1])+'/'+this.zeroFill(end[2]);
					end=new Date(end);
					var now=new Date(one.join("/"));
					var className="";
					if(one[0]==new Date(this.value).getFullYear()&&one[1]==new Date(this.value).getMonth()+1&&one[2]==new Date(this.value).getDate()){
						className+="on ";
					};
					if(now<start||now>end){
						className+='disabled';
						one=[];
					};
					this.datalist.push({"className":className,"num":(i-week),"date":one.join("-")});
				}else{
					this.datalist.push({"className":"disabled","num":"","date":""});
				};
			};
			this.datatop='<span class="top_month">'+this.getMonthText(this.month)+'</span><span class="top_year">'+this.year+'</span>';
		},
		clickDate:function(type,day,dates){
			switch (type){
				case 1:
					this.setDateInfo((this.year-1)+"/"+this.month+"/"+1);
					break;
				case 2:
					this.setDateInfo((this.month-1==0?this.year-1:this.year)+"/"+(this.month-1==0?12:this.month-1)+"/"+1);
					break;
				case 3:
					this.setDateInfo((this.month+1==13?this.year+1:this.year)+"/"+(this.month+1==13?1:this.month+1)+"/"+1);
					break;
				case 4:
					this.setDateInfo((this.year+1)+"/"+this.month+"/"+1);
					break;
				case 5:
					if(day){
						this.child.now=day;
						this.showCalendar();
						this.child.callback&&this.child.callback(day);
					};
					break;
				default:
					break;
			}
		},
		isDate:function(){
			var num=this.value.split("/");
			if(num.length==3&&!isNaN(num[0])&&!isNaN(num[1])&&!isNaN(num[2])){
				return true;
			};
			return false;
		},
		zeroFill:function(num){
			num=Number(num);
			num=num<10?"0"+num:num;
			return num;
		},
		getMonthText:function(m){
			var month='';
			switch(m){
	   		case 1:
	   			month="一月";
				break;
				case 2:
	   			month="二月";
	   			break;
	   		case 3:
	   			month="三月";
	   			break;
				case 4:
	   			month="四月";
	   			break;
	   		case 5:
	   			month="五月";
	   			break;
				case 6:
	   			month="六月";
	   			break;
	   		case 7:
	   			month="七月";
	   			break;
				case 8:
	   			month="八月";
	   			break;
	   		case 9:
	   			month="九月";
	   			break;
				case 10:
	   			month="十月";
	   			break;
	   		case 11:
	   			month="十一月";
	   			break;
				case 12:
	   			month="十二月";
	   			break;
			};
	    	return month;
		}
	},
	template:'<div class="m_calender">'+
				'<input type="type" class="date_input" readonly="readonly" v-model="child.now" @click="showCalendar">'+
				'<div class="date_main" v-if="open">'+
					'<div class="date_top">'+
						'<em class="prev_year" @click="clickDate(1)"></em>'+
						'<em class="prev_month" @click="clickDate(2)"></em>'+
						'<p v-html="datatop"></p>'+
						'<em class="next_month" @click="clickDate(3)"></em>'+
						'<em class="next_year" @click="clickDate(4)"></em>'+
				  	'</div>'+
				  	'<div class="date_week">'+
						'<em>日</em>'+
						'<em>一</em>'+
						'<em>二</em>'+
						'<em>三</em>'+
						'<em>四</em>'+
						'<em>五</em>'+
						'<em>六</em>'+
				  	'</div>'+
				  	'<div class="date_day"><em v-for="s in datalist" :class="s.className" @click="clickDate(5,s.date)">{{ s.num }}</em></div>'+
				  	'<div class="date_mask" @click="showCalendar"></div>'+
				'</div>'+
			'</div>'
});